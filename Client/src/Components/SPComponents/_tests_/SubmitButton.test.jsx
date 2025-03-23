import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { SubmitButton } from '../SubmitButton';
import { SurveyContext } from '../SurveyPage';
import { useNavigate } from 'react-router-dom';

jest.mock('react-router-dom', () => ({
  useNavigate: jest.fn(),
}));

jest.mock('../../../helpers/fetch', () => ({
        fetchApi: jest.fn()
}));

describe('SubmitButton Component', () => {
  // Dummy context value with a sample comment and voteResults
  const dummyResponse = {
    comment: "Test comment",
    voteResults: { "1": true, "2": false },
  };

  let setResponse, navigate;

  beforeEach(() => {
    setResponse = jest.fn();
    navigate = jest.fn();
    // Make useNavigate return our dummy navigate function
    useNavigate.mockReturnValue(navigate);
    // Mock global.fetch and a dummy wait function
    global.fetch = jest.fn();
    global.wait = jest.fn(() => Promise.resolve());
    jest.spyOn(window, 'alert').mockImplementation(() => {});
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  test('submits survey successfully and navigates to /results', async () => {
    // Simulate a successful POST for the survey comment which returns a surveyId ("123")
    global.fetch
      // First fetch call: POST to /api/Surveys
      .mockResolvedValueOnce({
        json: () => Promise.resolve("123"),
      })
      // Second fetch call: POST for the first vote result (for foodItem "1")
      .mockResolvedValueOnce({
        json: () => Promise.resolve({}),
      })
      // Third fetch call: POST for the second vote result (for foodItem "2")
      .mockResolvedValueOnce({
        json: () => Promise.resolve({}),
      });

    render(
      <SurveyContext.Provider value={{ response: dummyResponse, setResponse }}>
        <SubmitButton />
      </SurveyContext.Provider>
    );

    // Simulate a click on the Submit button (BasicButton)
    const button = screen.getByText("Submit");
    fireEvent.click(button);

    // Wait for all async operations to complete (3 fetch calls expected)
    await waitFor(() => {
      expect(global.fetch).toHaveBeenCalledTimes(3);
    });

    // Expect that setResponse is called with an empty object to clear the survey
    expect(setResponse).toHaveBeenCalledWith({});
    // And that navigate is called with '/results' after successful submission
    expect(navigate).toHaveBeenCalledWith('/results');
  });

  test('handles submission error and navigates to / after alert', async () => {
    // Simulate a failure on the first fetch call (POST to /api/Surveys)
    const error = new Error("Test error");
    global.fetch.mockRejectedValueOnce(error);

    render(
      <SurveyContext.Provider value={{ response: dummyResponse, setResponse }}>
        <SubmitButton />
      </SurveyContext.Provider>
    );

    // Click the Submit button
    const button = screen.getByText("Submit");
    fireEvent.click(button);

    // Wait for the async error handling
    await waitFor(() => {
      // Check that window.alert is called with the appropriate error message
      expect(window.alert).toHaveBeenCalledWith(
        "There was an error submitting your survey. We value your feedback. Please resubmit your survey."
      );
    });

    // Expect that setResponse is called with {} even on error
    expect(setResponse).toHaveBeenCalledWith({});
    // And that navigate is called with '/' after the error handling completes
    expect(navigate).toHaveBeenCalledWith('/');
  });
});