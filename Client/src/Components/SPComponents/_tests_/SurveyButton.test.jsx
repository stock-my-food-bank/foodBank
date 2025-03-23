import { render, screen, fireEvent } from '@testing-library/react';
import { SurveyButton } from '../surveyButton';
import { SurveyContext } from '../SurveyPage';

jest.mock('../../../helpers/fetch', () => (
    {
        fetchApi: jest.fn()
    }
));

describe('SurveyButton Component', () => {
  const foodItemId = '1';

  // Helper function to render the component with the provided context.
  const renderWithContext = (response, setResponse = jest.fn()) => {
    return render(
      <SurveyContext.Provider value={{ response, setResponse }}>
        <SurveyButton foodItemId={foodItemId} />
      </SurveyContext.Provider>
    );
  };

  test('renders Yes, No, and Skip buttons', () => {
    const dummyResponse = { voteResults: {} };
    renderWithContext(dummyResponse);

    expect(screen.getByText('Yes')).toBeInTheDocument();
    expect(screen.getByText('No')).toBeInTheDocument();
    expect(screen.getByText('Skip')).toBeInTheDocument();
  });

  test('clicking "Yes" button calls setResponse with vote true', () => {
    const setResponse = jest.fn();
    const dummyResponse = { voteResults: {} };
    renderWithContext(dummyResponse, setResponse);

    fireEvent.click(screen.getByText('Yes'));
    expect(setResponse).toHaveBeenCalledWith({
      voteResults: {
        [foodItemId]: true,
      },
    });
  });

  test('clicking "No" button calls setResponse with vote false', () => {
    const setResponse = jest.fn();
    const dummyResponse = { voteResults: {} };
    renderWithContext(dummyResponse, setResponse);

    fireEvent.click(screen.getByText('No'));
    expect(setResponse).toHaveBeenCalledWith({
      voteResults: {
        [foodItemId]: false,
      },
    });
  });

  test('clicking "Skip" button calls setResponse with vote null', () => {
    const setResponse = jest.fn();
    const dummyResponse = { voteResults: {} };
    renderWithContext(dummyResponse, setResponse);

    fireEvent.click(screen.getByText('Skip'));
    expect(setResponse).toHaveBeenCalledWith({
      voteResults: {
        [foodItemId]: null,
      },
    });
  });

  test('applies the active class correctly based on voteResults', () => {
    const setResponse = jest.fn();

    // Test for active "Yes" button when vote is true.
    const responseYes = { voteResults: { [foodItemId]: true } };
    const { rerender } = render(
      <SurveyContext.Provider value={{ response: responseYes, setResponse }}>
        <SurveyButton foodItemId={foodItemId} />
      </SurveyContext.Provider>
    );
    expect(screen.getByText('Yes').className).toContain('active');

    // Test for active "No" button when vote is false.
    const responseNo = { voteResults: { [foodItemId]: false } };
    rerender(
      <SurveyContext.Provider value={{ response: responseNo, setResponse }}>
        <SurveyButton foodItemId={foodItemId} />
      </SurveyContext.Provider>
    );
    expect(screen.getByText('No').className).toContain('active');

    // Test for active "Skip" button when vote is null.
    const responseSkip = { voteResults: { [foodItemId]: null } };
    rerender(
      <SurveyContext.Provider value={{ response: responseSkip, setResponse }}>
        <SurveyButton foodItemId={foodItemId} />
      </SurveyContext.Provider>
    );
    expect(screen.getByText('Skip').className).toContain('active');
  });
});