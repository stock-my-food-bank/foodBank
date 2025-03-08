import React, {useState} from 'react';

function ResultsButton() {
   
    return (
        <div>
            <button className="btn btn-info" onClick={handleSubmit}>
                Results
          </button>
        </div>
    );
}
export default ResultsButton;
