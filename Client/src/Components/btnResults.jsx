import React, {useState} from 'react';

function ResultsButton() {
   
    const handleSubmit = () => {
        console.log('Results Button has been clicked!');
    };
    return (
        <div>
            <button className="btn btn-info" onClick={handleSubmit}>
                Results
          </button>
        </div>
    );
}
export default ResultsButton;
