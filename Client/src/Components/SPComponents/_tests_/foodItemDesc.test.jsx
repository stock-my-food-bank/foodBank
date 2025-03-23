// FoodItemDesc.test.js

import React from 'react';
import { render, screen } from '@testing-library/react';
import { FoodItemDesc } from '../foodItemDesc';

// Mock the FoodImg component so that we can inspect its props.
// Here, the mock returns an <img> element with the src and alt attributes set based on the props.
jest.mock('../FoodImg', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        FoodImg: ({ img, foodItemTitle }) =>
        jsx(
            'div',
            { 
                'data-testid': 'mock-food-img',
                "src": img,
                'alt': foodItemTitle
            }
        )
    }
});

describe('FoodItemDesc Component', () => {
  test('renders the food item title', () => {
    const title = 'Delicious Pizza';
    render(<FoodItemDesc foodItemId="1" foodItemTitle={title} foodItemImg="pizza.jpg" />);
    
    // Check that the foodItemTitle text is rendered
    expect(screen.getByText(title)).toBeInTheDocument();
  });

  test('renders FoodImg component with correct props', () => {
    const title = 'Tasty Burger';
    const imgUrl = 'burger.jpg';
    render(<FoodItemDesc foodItemId="2" foodItemTitle={title} foodItemImg={imgUrl} />);
    
    // Locate the mocked FoodImg by its test id
    const imgElement = screen.getByTestId('mock-food-img');
    expect(imgElement).toHaveAttribute('src', imgUrl);
    expect(imgElement).toHaveAttribute('alt', title);
  });

  test('renders container with proper CSS classes', () => {
    const { container } = render(
      <FoodItemDesc foodItemId="3" foodItemTitle="Fresh Salad" foodItemImg="salad.jpg" />
    );
    // The top-level div should have the following classes
    expect(container.firstChild).toHaveClass('d-flex');
    expect(container.firstChild).toHaveClass('justify-content-around');
    expect(container.firstChild).toHaveClass('flex-column');
    expect(container.firstChild).toHaveClass('flex-fill');
  });
});
