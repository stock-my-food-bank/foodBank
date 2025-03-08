import React, {useState} from 'react';

function ResultsButton() {
   
    const handleResults = () => {
        console.log('Results Button has been clicked!');
    };
    return (
        <div>
            <button className="btn btn-info" onClick={handleResults}>
                Results
          </button>
        </div>
    );
}
export default ResultsButton;
