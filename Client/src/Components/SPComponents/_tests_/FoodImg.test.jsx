import React from 'react';
import { render, screen } from '@testing-library/react';
import { FoodImg } from '../FoodImg';

describe('FoodImg Component', () => {
  const imgUrl = 'test.jpg';
  const foodItemTitle = 'Pizza';

  test('renders an image with correct src and alt attributes', () => {
    render(<FoodImg img={imgUrl} foodItemTitle={foodItemTitle} />);
    const imgElement = screen.getByRole('img');

    expect(imgElement).toHaveAttribute('src', imgUrl);
    expect(imgElement).toHaveAttribute('alt', `${foodItemTitle} Image`);
  });

  test('applies the correct CSS classes', () => {
    render(<FoodImg img={imgUrl} foodItemTitle={foodItemTitle} />);
    const imgElement = screen.getByRole('img');

    expect(imgElement).toHaveClass('align-middle');
    expect(imgElement).toHaveClass('p-0');
    expect(imgElement).toHaveClass('foodImg');
  });

  test('applies the inline style correctly', () => {
    render(<FoodImg img={imgUrl} foodItemTitle={foodItemTitle} />);
    const imgElement = screen.getByRole('img');

    expect(imgElement).toHaveStyle({ maxHeight: '5.5rem' });
  });
});