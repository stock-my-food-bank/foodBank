// Needed for routes as we are importing from the library
import { useNavigate } from 'react-router-dom';
//Nyambura --Imported Basic Button Styling  
import { BasicButton } from '../BasicButton'
import { useContext } from 'react';
import { SurveyContext } from './SurveyPage';


/*
Murphree - pop ups now handled through alerts if error occurs.
Submits a complete survey
      - first creates the comment and survey Id, along with a dummy user for now
      - takes the surveyId and inputs into post call for each individual survey result for each fooditem -- information pulled from response using context
      - try catch to give pop up message if submit is unsuccessful
*/
export const SubmitButton = () => {
    const {response, setResponse} = useContext(SurveyContext);
    const navigate = useNavigate();

    const onClickHandler = async(e) => {
        //post for comment and survey, returning surveyId
        try { 
            const res = await fetch('https://localhost:5252/api/Surveys', {
                method: "POST",
                headers: {"Content-Type": "application/json"}, 
                body: JSON.stringify(response.comment),
            });

            const surveyId = await res.json()

            //Murphree map through vote results and do a post call for each vote 
            const results = Object.entries(response.voteResults).map(async ([fooditem, voteResult]) => {
                const voteRes = await fetch('https://localhost:5252/api/SurveyFoodItemResults', {
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
            //Murphree - by mapping it returns a promise, this awaits the promise to come back resolved
            await Promise.all(results);
            //Murphree - resetting response to empty object to clear survey once submitted
            setResponse({});
            //Murphree - navigates to result after fetch calls complete
            //Murphree - future iteration consider not rewriting response and having a count and if retry has already happened then overwrite data and ask user to re-enter info.
            navigate('/results') 
        } catch (error) {
            console.log("submitButtonError", error.message)
            // alert(error.message);
            alert("There was an error submitting your survey. We value your feedback. Please resubmit your survey.")
            setResponse({});
            await wait(5000);
            navigate('/')
        }
    }
    
    return(
            <BasicButton 
                text="Submit" 
                onClickHandler={onClickHandler} 
            />
    );
}