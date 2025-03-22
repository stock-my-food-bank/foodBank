import { useContext } from "react";
import { SurveyContext } from "./SurveyPage";

//Nyambura Comments section for view 1 
//Murphree - uses response useContext to save comments entered through onChangeHandler, will then be accessible for submitButton
function Comments ({}) {

    const {response, setResponse} = useContext(SurveyContext);

    const onChangeHandler = (e) => {
        setResponse({
            ...response,
            comment: e.target.value
        })
    }
    
    return (
        <>
            <div className="mb-3">
                <label for="exampleFormControlTextarea1" className="form-label d-flex ">Provide comments here...</label>
                <textarea className="form-control" id="exampleFormControlTextarea1" rows="3" onChange={onChangeHandler}/>
            </div>
        </>
    );
}
export default Comments; 