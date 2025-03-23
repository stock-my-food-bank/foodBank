import React from 'react';
import { render, screen, waitFor, fireEvent } from '@testing-library/react';
import { RPComments, Comment } from '../RPComments';

// Helper function to wait for a specified number of milliseconds
function wait(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

describe('RPComments Component', () => {
  beforeEach(() => {
    global.fetch = jest.fn();
    jest.spyOn(window, 'alert').mockImplementation(() => {});
  });

  afterEach(() => {
    jest.restoreAllMocks();
  });

  test('renders loading state initially', () => {
    // Simulate a fetch call that never resolves to keep the component in loading state
    global.fetch.mockReturnValue(new Promise(() => {}));
    render(<RPComments />);
    expect(screen.getByText("loading...")).toBeInTheDocument();
  });

  test('renders comments and "Show More" behavior on successful API call', async () => {
    // Create dummy comments data (7 comments)
    const commentsData = [
      { comment: "Comment 1", dateTime: "2023-03-20" },
      { comment: "Comment 2", dateTime: "2023-03-21" },
      { comment: "Comment 3", dateTime: "2023-03-22" },
      { comment: "Comment 4", dateTime: "2023-03-23" },
      { comment: "Comment 5", dateTime: "2023-03-24" },
      { comment: "Comment 6", dateTime: "2023-03-25" },
      { comment: "Comment 7", dateTime: "2023-03-26" },
    ];

    // Simulate a successful fetch returning the commentsData
    global.fetch.mockResolvedValue({
      ok: true,
      json: async () => commentsData,
    });

    render(<RPComments />);
    
    // Wait a short time to allow useEffect to run
    await wait(50);

    // Wait until the list is rendered (RPComments renders a <ul> when comments are loaded)
    await waitFor(() => {
      expect(screen.getByRole('list')).toBeInTheDocument();
    });

    // Initially, only 5 comments should be visible (each rendered as a <li>)
    let listItems = screen.getAllByRole('listitem');
    expect(listItems).toHaveLength(5);

    // "Show More" link should be present since there are more comments than visible
    const showMoreLink = screen.getByText("Show More");
    expect(showMoreLink).toBeInTheDocument();

    // Simulate clicking "Show More" to load additional comments
    fireEvent.click(showMoreLink);

    // After clicking, all comments (7) should be visible
    await waitFor(() => {
      listItems = screen.getAllByRole('listitem');
      expect(listItems).toHaveLength(7);
    });

    // "Show More" link should no longer be rendered once all comments are visible
    expect(screen.queryByText("Show More")).toBeNull();
  });

  test('alerts an error message when the API call fails', async () => {
    const errorMessage = "Test error";
    // Simulate fetch rejecting with an Error
    global.fetch.mockRejectedValue(new Error(errorMessage));

    render(<RPComments />);

    await waitFor(() => {
      expect(window.alert).toHaveBeenCalledWith(errorMessage);
    });
  });
});

describe('Comment Component', () => {
  test('renders comment text and date properly', () => {
    render(<Comment comment="Test comment" date="2023-03-20" />);
    
    // Check that the comment text is rendered
    expect(screen.getByText("Test comment")).toBeInTheDocument();
    
    // Check that the date is rendered as part of the badge text
    expect(screen.getByText("Date: 2023-03-20")).toBeInTheDocument();

    // Verify that the list item has the expected Bootstrap classes
    const liElement = screen.getByText("Test comment").closest('li');
    expect(liElement).toHaveClass("list-group-item");
    expect(liElement).toHaveClass("d-flex");
    expect(liElement).toHaveClass("justify-content-between");
    expect(liElement).toHaveClass("align-items-center");
  });
});