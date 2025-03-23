import React from 'react';
import { render, screen, waitFor, fireEvent } from '@testing-library/react';
import { ResultsPage } from '../ResultsPage';

// Helper function to pause execution for a given time (ms)
function wait(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

jest.mock('../../../helpers/fetch', () => (
    {
        fetchApi: jest.fn()
    }
));

// Mocks for child components similar to SurveyPage tests
jest.mock('../../Logo', () => {
  const { jsx } = require('react/jsx-runtime');
  return {
    Logo: () => jsx('div', { 'data-testid': 'logo' })
  };
});
jest.mock('../../BasicButton', () => {
  const { jsx } = require('react/jsx-runtime');
  return {
    BasicButton: ({ text, ...props }) =>
      jsx('button', { 'data-testid': 'basic-button', children: text, ...props })
  };
});
jest.mock('../RPComments', () => {
  const { jsx } = require('react/jsx-runtime');
  return {
    RPComments: () =>
      jsx('div', { 'data-testid': 'rp-comments' })
  };
});
jest.mock('react-router-dom', () => {
  const { jsx } = require('react/jsx-runtime');
  return {
    Link: ({ to, children }) =>
      jsx('a', { 'data-testid': 'results-link', href: to, children })
  };
});

describe('ResultsPage Component', () => {
  beforeEach(() => {
    // Override global fetch (used directly in ResultsPage)
    global.fetch = jest.fn();
    global.alert = jest.fn();
  });

  afterEach(() => {
    jest.restoreAllMocks();
  });

  test('renders loading state when foodItems are empty', async () => {
    // Simulate first API call (votes) returns data,
    // but second API call (FoodItems) returns an empty array so foodItems remains {}.
    const votesData = [{ foodItemId: "1", voteCountYes: 10, voteCountNo: 5 }];
    global.fetch
      .mockResolvedValueOnce({
        ok: true,
        json: async () => votesData,
      })
      .mockResolvedValueOnce({
        ok: true,
        json: async () => [],
      });

    render(<ResultsPage />);
    expect(screen.getByText("loading...")).toBeInTheDocument();
  });

  test('renders static components and maps results on successful API calls', async () => {
    // Dummy data: two votes and a foodItems list (which is converted into a map)
    const votesData = [
      { foodItemId: "1", voteCountYes: 10, voteCountNo: 5 },
      { foodItemId: "2", voteCountYes: 3, voteCountNo: 7 }
    ];
    const foodItemsData = [
      { id: "1", title: "Pizza" },
      { id: "2", title: "Burger" }
    ];

    // First fetch call: returns votesData; second fetch call: returns foodItemsData.
    global.fetch
      .mockResolvedValueOnce({
        ok: true,
        json: async () => votesData,
      })
      .mockResolvedValueOnce({
        ok: true,
        json: async () => foodItemsData,
      });

    render(<ResultsPage />);
    // Allow useEffects to run
    await wait(50);
    await waitFor(() => expect(screen.queryByText("loading...")).toBeNull());

    // Verify static components are rendered.
    // Two logos are rendered (header and footer)
    expect(screen.getAllByTestId('logo').length).toBeGreaterThan(0);
    expect(screen.getByTestId('basic-button')).toHaveTextContent("Back");
    expect(screen.getByText("StockMyFoodBank")).toBeInTheDocument();
    expect(screen.getByText("Results")).toBeInTheDocument();

    // Verify the votes are mapped to ItemResults.
    // In ResultsPage, for each vote, an ItemResults is rendered (which includes a table).
    const tables = screen.getAllByRole('table');
    expect(tables.length).toBe(2);
    // The first ItemResults should render the food item title.
    // Since foodItemMap maps "1" to "Pizza", verify that "Pizza" is rendered.
    expect(screen.getByText("Pizza")).toBeInTheDocument();

    // Verify that RPComments is rendered.
    expect(screen.getByTestId("rp-comments")).toBeInTheDocument();

    // Verify that the back navigation link is rendered correctly.
    expect(screen.getByTestId("results-link")).toHaveAttribute("href", "/");
  });
});