import { render, screen } from '@testing-library/react';
import { SPColumn } from '../SPColumn';

// Mock the SPRow component to simply render text that includes its props.
jest.mock('../SPRow', () => {
    const { jsx } = require('react/jsx-runtime')
    return {
        SPRow: ({ foodItem, rowType }) => 
            jsx(
                'div', {
                    'data-testid': 'sp-row',
                    'children': `${foodItem.title} - ${rowType}`,
            })
    }
});

describe('SPColumn Component', () => {
  const foodItems = [
    { id: '1', title: 'Pizza', image: 'pizza.jpg' },
    { id: '2', title: 'Burger', image: 'burger.jpg' }
  ];

  test('renders header and uses ordered list when numbered is true', () => {
    render(
      <SPColumn
        header="Test Header"
        columnType="foodItems"
        foodItemList={foodItems}
        numbered={true}
      />
    );

    // Check header rendering inside an h5 element.
    expect(screen.getByRole('heading', { level: 5 })).toHaveTextContent('Test Header');

    // Check that the list is rendered as an ordered list (<ol>) with the proper classes.
    const listElement = screen.getByRole('list');
    expect(listElement.tagName).toBe('OL');
    expect(listElement).toHaveClass('list-group', 'list-group-numbered');

    // Ensure that an SPRow is rendered for each food item.
    const spRows = screen.getAllByTestId('sp-row');
    expect(spRows).toHaveLength(2);
    expect(spRows[0]).toHaveTextContent('Pizza - foodItems');
    expect(spRows[1]).toHaveTextContent('Burger - foodItems');
  });

  test('renders header and uses unordered list when numbered is false', () => {
    render(
      <SPColumn
        header="Another Header"
        columnType="buttons"
        foodItemList={foodItems}
        numbered={false}
      />
    );

    // Check header rendering.
    expect(screen.getByRole('heading', { level: 5 })).toHaveTextContent('Another Header');

    // The list should be rendered as an unordered list (<ul>) and not include the numbered class.
    const listElement = screen.getByRole('list');
    expect(listElement.tagName).toBe('UL');
    expect(listElement).toHaveClass('list-group');
    expect(listElement).not.toHaveClass('list-group-numbered');

    // Verify that each food item maps to an SPRow.
    const spRows = screen.getAllByTestId('sp-row');
    expect(spRows).toHaveLength(2);
    expect(spRows[0]).toHaveTextContent('Pizza - buttons');
    expect(spRows[1]).toHaveTextContent('Burger - buttons');
  });

  test('renders "No items available" when foodItemList is not an array', () => {
    render(
      <SPColumn
        header="Empty Column"
        columnType="foodItems"
        foodItemList={null}
        numbered={false}
      />
    );

    // Check that the "No items available" message is rendered.
    expect(screen.getByText('No items available')).toBeInTheDocument();
  });
});