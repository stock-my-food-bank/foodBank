import React from 'react';
import { render, screen } from '@testing-library/react';
import { Logo } from '../Logo';

describe('Logo Component', () => {
  test('renders the logo text', () => {
    render(<Logo />);
    const logoText = screen.getByText('StockMyFoodBank');
    expect(logoText).toBeInTheDocument();
    expect(logoText).toHaveClass('navbar-brand ms-4 h1 p-2');
  });

  test('renders container with correct classes', () => {
    const { container } = render(<Logo />);
    const containerDiv = container.firstChild;
    expect(containerDiv).toHaveClass('Container-fluid');
    expect(containerDiv).toHaveClass('d-flex');
    expect(containerDiv).toHaveClass('p-3');
    expect(containerDiv).toHaveClass('Stock-Color');
  });

  // Optional: Snapshot test to detect unexpected changes
  test('matches snapshot', () => {
    const { asFragment } = render(<Logo />);
    expect(asFragment()).toMatchSnapshot();
  });
});