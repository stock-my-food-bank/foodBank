import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import { BasicButton } from '../BasicButton';

describe('BasicButton Component', () => {
  test('renders with correct text', () => {
    const text = 'Click Me';
    render(<BasicButton text={text} />);
    expect(screen.getByText(text)).toBeInTheDocument();
  });

  test('has the correct class names', () => {
    const text = 'Test Button';
    render(<BasicButton text={text} />);
    const button = screen.getByText(text);
    expect(button).toHaveClass('custom-btn');
    expect(button).toHaveClass('m-3');
  });

  test('calls onClickHandler when clicked', () => {
    const text = 'Click Me';
    const handleClick = jest.fn();
    render(<BasicButton text={text} onClickHandler={handleClick} />);
    const button = screen.getByText(text);
    fireEvent.click(button);
    expect(handleClick).toHaveBeenCalledTimes(1);
  });
});