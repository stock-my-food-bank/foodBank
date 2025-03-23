import { useContext } from "react";
import { SurveyContext } from "./SurveyPage";

// Murphree - response used to take in information from other components on SurveyPage
export const SurveyButton = ({foodItemId}) => {
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
    const yesActive = response.voteResults? response.voteResults[foodItemId] : false;
    const noActive = response.voteResults? response.voteResults[foodItemId] === false : false;
    const skipActive = response.voteResults? response.voteResults[foodItemId] === null : false;
    return (
        <div className="d-flex flex-fill flex-column h-100 justify-content-center tablet-font">
            <div className="btn-group tablet-font" role="group" aria-label="Basic outlined example">
                <button type="button" className={`btn btn-lg btn-outline-dark ${yesActive? "active" : ""}`} onClick={onClickHandler(true)}>Yes</button>
                <button type="button" className={`btn btn-lg btn-outline-dark ${noActive? "active" : ""}`} onClick={onClickHandler(false)}>No</button>
                <button type="button" className={`btn btn-lg btn-outline-dark ${skipActive? "active" : ""}`} onClick={onClickHandler(null)}>Skip</button>
            </div>
        </div>
    );
}