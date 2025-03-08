import React, {useState} from 'react';


function SubmitButton() {

    //Initialize state to control te alert visibility
    const [showAlert, setShowAlert] = useState(false);

    //Handle button click event 
    const handleSubmit = () => {
        setShowAlert(true); //Shows the alert when submit button is clicked

    };

    return (
        <div>
            <button className="btn btn-info" onClick={handleSubmit}>
                Submit
          </button>
          
        </div>
    );
}

export default SubmitButton;
