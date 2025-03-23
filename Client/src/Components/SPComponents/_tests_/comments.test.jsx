import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import { Comments } from '../Comments';
import { SurveyContext } from '../SurveyPage';

jest.mock('../../../helpers/fetch', () => (
    {
        fetchApi: jest.fn()
    }
));

describe('Comments Component', () => {
  // Use an initial dummy response object (can be empty or contain preexisting values)
  const dummyResponse = {};
  let setResponse;

  // Helper function to render Comments with context
  const renderWithContext = () =>
    render(
      <SurveyContext.Provider value={{ response: dummyResponse, setResponse }}>
        <Comments />
      </SurveyContext.Provider>
    );

  beforeEach(() => {
    // Create a new mock for setResponse for each test
    setResponse = jest.fn();
  });

  test('renders label and textarea', () => {
    renderWithContext();

    // Verify that the label is rendered
    expect(
      screen.getByText('Provide comments here...')
    ).toBeInTheDocument();

    // Verify that the textarea is rendered with the correct id
    const textarea = screen.getByRole('textbox');
    expect(textarea).toBeInTheDocument();
    expect(textarea).toHaveAttribute('id', 'exampleFormControlTextarea1');
  });

  test('calls setResponse with updated comment on change', () => {
    renderWithContext();

    // Get the textarea and simulate a change event with a new comment value
    const textarea = screen.getByRole('textbox');
    fireEvent.change(textarea, { target: { value: 'Test comment' } });

    // Expect setResponse to be called with the updated response merging the comment
    expect(setResponse).toHaveBeenCalledWith({
      ...dummyResponse,
      comment: 'Test comment',
    });
  });
});