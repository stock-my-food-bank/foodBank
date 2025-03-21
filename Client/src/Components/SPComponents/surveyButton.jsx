import { useContext } from "react";
import { SurveyContext } from "./SurveyPage";

function SurveyButton ({foodItemId}) {
    const {response, setResponse} = useContext(SurveyContext);

    //Murphree - vote is true, false, or null which stands for yes, no, or skip
    const onClickHandler = (vote) => () => {
        setResponse({
            voteResults: {
                ...response.voteResults,
                [foodItemId]: vote,
            }
        })
    }
    const yesActive = response.voteResults[foodItemId];
    const noActive = response.voteResults[foodItemId] === false;
    const skipActive = response.voteResults[foodItemId] === null;
    return (
        <div className="d-flex flex-fill flex-column h-100 justify-content-center">
            <div className="btn-group" role="group" aria-label="Basic outlined example">
                <button type="button" className={`btn btn-lg btn-outline-dark ${yesActive? "active" : ""}`} onClick={onClickHandler(true)}>Yes</button>
                <button type="button" className={`btn btn-lg btn-outline-dark ${noActive? "active" : ""}`} onClick={onClickHandler(false)}>No</button>
                <button type="button" className={`btn btn-lg btn-outline-dark ${skipActive? "active" : ""}`} onClick={onClickHandler(null)}>Skip</button>
            </div>
        </div>
    );
}

export default SurveyButton;