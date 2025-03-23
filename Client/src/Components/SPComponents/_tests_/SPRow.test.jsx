import { render, screen } from '@testing-library/react';
import { SPRow } from '../SPRow';


// Mock FoodItemDesc to simply render the passed props in a test element.
jest.mock('../foodItemDesc', () => {
    const { jsx } = require('react/jsx-runtime');
    return {
        FoodItemDesc: ({ foodItemTitle, foodItemImg }) => 
            jsx(
                'div', {
                    "data-testid": "food-item-desc",
                    'children': `${foodItemTitle} - ${foodItemImg}`,
            })
    }
});

// Mock SurveyButton to render a test element that shows the foodItemId.
jest.mock('../surveyButton', () => {
    const { jsx } = require('react/jsx-runtime');
    return {
        SurveyButton: ({ foodItemId }) => 
            jsx(
                'div', {
                    'data-testid': "survey-button",
                    children: foodItemId
            })
    }
});

describe('SPRow Component', () => {
  test('renders a foodItems row correctly', () => {
    const foodItem = { title: 'Pizza', image: 'pizza.jpg', id: '1' };

    render(<SPRow foodItem={foodItem} rowType="foodItems" />);
    
    // The list item should have the appropriate classes.
    const liElement = screen.getByRole('listitem');
    expect(liElement).toHaveClass('list-group-item');
    expect(liElement).toHaveClass('d-flex');
    expect(liElement).toHaveClass('align-items-start');
    expect(liElement).toHaveClass('list-item');

    // Verify that the FoodItemDesc component was rendered with the correct props.
    const foodItemDesc = screen.getByTestId('food-item-desc');
    expect(foodItemDesc).toBeInTheDocument();
    expect(foodItemDesc).toHaveTextContent('Pizza - pizza.jpg');
  });

  test('renders a buttons row correctly', () => {
    const foodItem = { title: 'Burger', image: 'burger.jpg', id: '2' };

    render(<SPRow foodItem={foodItem} rowType="buttons" />);
    
    // The list item should have a different set of classes.
    const liElement = screen.getByRole('listitem');
    expect(liElement).toHaveClass('list-group-item');
    expect(liElement).toHaveClass('list-group-item-action');
    expect(liElement).toHaveClass('list-item');

    // Verify that the SurveyButton component was rendered with the correct foodItemId.
    const surveyButton = screen.getByTestId('survey-button');
    expect(surveyButton).toBeInTheDocument();
    expect(surveyButton).toHaveTextContent('2');
  });
});
