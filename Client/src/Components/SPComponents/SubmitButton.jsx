// Needed for routes as we are importing from the library
import { useNavigate } from 'react-router-dom';
//Nyambura --Imported Basic Button Styling  
import BasicButton from '../BasicButton'
import { useContext } from 'react';
import { SurveyContext } from './SurveyPage';

function SubmitButton () {
    const {response, setResponse} = useContext(SurveyContext);
    const navigate = useNavigate();

    const onClickHandler = async(e) => {
        //post for comment and survey, returning surveyId
        const res = await fetch('https://localhost:7183/api/Surveys', {
            method: "POST",
            headers: {"Content-Type": "application/json"}, 
            body: JSON.stringify(response.comment),
        });
        const surveyId = await res.json()

        //Murphree map through vote results and do a post call for each vote 
        Object.entries(response.voteResults).map(async ([fooditem, voteResult]) => {
            const voteRes = await fetch('https://localhost:7183/api/SurveyFoodItemResults', {
                method: "POST",
                headers: {"Content-Type": "application/json"}, 
                body: JSON.stringify({
                    voteCountYes: voteResult ? true : false,
                    voteCountNo: voteResult === false ? true : false, 
                    foodItemId: fooditem,
                    surveyId: surveyId,
                }),
            })
        })
        //Murphree - resetting response to empty object to clear survey once submitted
        setResponse({});
        //Murphree - navigates to result after fetch calls complete
        navigate('/results')
    };


    return(
            <BasicButton 
                text="Submit" 
                onClickHandler={onClickHandler} 
            />
    );
}

export default SubmitButton;