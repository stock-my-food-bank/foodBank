import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import { SurveyPage } from '../SurveyPage';

function wait(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

jest.mock('../../../helpers/fetch', () => (
    {
        fetchApi: jest.fn()
    }
));

import { fetchApi } from "../../../helpers/fetch";

// Mock child components to isolate SurveyPage tests
jest.mock('../../BasicButton', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        BasicButton: ({text}) =>
            jsx(
                'button',
                {
                    'data-testid': "basic-button",
                    children: text
                },
        )}     
})
jest.mock('../FoodItems', () => {
    const { jsx } = require('react/jsx-runtime');
    return {
        FoodItems: ({foodItemList}) => 
            jsx(
                'div',
                {
                    'data-testid': 'food-items',
                    'data-food-items': JSON.stringify(foodItemList),
                }            
    )}
});
jest.mock('../Comments', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        Comments: ({}) =>
            jsx(
                'div',
                {
                    'data-testid': "comments",
                },
        )}     
})
jest.mock('../../Logo', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        Logo: ({}) =>
            jsx(
                'div',
                {
                    'data-testid': "logo",
                },
        )}     
})
jest.mock('../SubmitButton', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        SubmitButton: ({}) =>
            jsx(
                'button',
                {
                    'data-testid': "submit-button",
                },
        )}     
})
jest.mock('react-router-dom', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        Link: ({to, children}) =>
            jsx(
                'button',
                {
                    'data-testid': "results-link",
                    'to-target': to,
                    children
                },
        )}     
})


describe('SurveyPage Component', () => {
    beforeEach(() => {
        fetchApi.mockClear()
        jest.spyOn(window, 'alert').mockImplementation(() => {});
    })

    afterEach(() => {
        jest.restoreAllMocks();
      });

    test('renders all static components and passes food items data on successful API call', async() => {
        const foodItemsData = [{ id: 1, name: 'Pizza' }, { id: 2, name: 'Burger' }];
        fetchApi.mockReturnValue({
            ok: true,
            status: 200,
            json: async () => foodItemsData,
        });
        render(<SurveyPage />);
        await wait(50);            
        expect(screen.getAllByTestId('logo').length).toBeGreaterThan(0);
        expect(screen.getByTestId('basic-button')).toHaveTextContent('Results');
        expect(screen.getByTestId('comments')).toBeInTheDocument();
        expect(screen.getByTestId('submit-button')).toBeInTheDocument();

        // Wait for the FoodItems component to render after the API call completes
        await waitFor(() => {
            expect(screen.getByTestId('food-items')).toBeInTheDocument();
        });
  
        // Verify that FoodItems received the correct food item list
        const foodItemsElement = screen.getByTestId('food-items');
        expect(foodItemsElement).toHaveAttribute('data-food-items', JSON.stringify(foodItemsData));
    });
    
    

    test('alerts an error message when the API call fails', async () => {
        // Simulate an API error response
        const errorStatus = 500;
        const errorMessage = `Response Status: ${errorStatus}`;
        fetchApi.mockResolvedValue({
          ok: false,
          status: 500,
          json: async () => [],
        });
    
        render(<SurveyPage />);
    
        // Wait for the useEffect to trigger and catch the error, causing alert to be called
        await waitFor(() => {
          expect(window.alert).toHaveBeenCalledWith(errorMessage);
        });
      });
    });