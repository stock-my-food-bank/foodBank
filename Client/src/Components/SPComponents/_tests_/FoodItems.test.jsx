import React from 'react';
import { render, screen } from '@testing-library/react';
import { FoodItems } from '../FoodItems';

// Mock SPColumn to output its props for testing purposes.
jest.mock('../SPColumn', () => {
    const { jsx } = require('react/jsx-runtime');
    return {
        SPColumn: (props) => 
            jsx(
            // Render a div with a data-testid and stringify the props into a data attribute.
            'div', {
                'data-testid': 'sp-column',
                'data-props': `${JSON.stringify(props)}`
            })
    }
  
});

describe('FoodItems Component', () => {
  const dummyFoodItems = [
    { id: '1', title: 'Pizza', image: 'pizza.jpg' },
    { id: '2', title: 'Burger', image: 'burger.jpg' },
  ];

  test('renders container structure', () => {
    render(<FoodItems foodItemList={dummyFoodItems} />);
    // Check that the outer container with class "container-fluid" is present.
    const container = screen.getByText((content, element) => {
      return (
        element.tagName.toLowerCase() === 'div' &&
        element.className.includes('container-fluid')
      );
    });
    expect(container).toBeInTheDocument();
  });

  test('renders two SPColumn components with correct props', () => {
    render(<FoodItems foodItemList={dummyFoodItems} />);
    const spColumns = screen.getAllByTestId('sp-column');
    expect(spColumns).toHaveLength(2);

    // Verify props for the first SPColumn.
    const firstProps = JSON.parse(spColumns[0].getAttribute('data-props'));
    expect(firstProps.header).toBe("Items being considered by the foodbank:");
    expect(firstProps.columnType).toBe("foodItems");
    expect(firstProps.foodItemList).toEqual(dummyFoodItems);
    expect(firstProps.numbered).toBe(true);

    // Verify props for the second SPColumn.
    const secondProps = JSON.parse(spColumns[1].getAttribute('data-props'));
    expect(secondProps.header).toBe("Would you select this item during a visit?");
    expect(secondProps.columnType).toBe("buttons");
    expect(secondProps.foodItemList).toEqual(dummyFoodItems);
    // Since the numbered prop is not passed, it should be undefined.
    expect(secondProps.numbered).toBeUndefined();
  });
});