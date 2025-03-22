//Nyambura --Imported Basic Button Styling  
import BasicButton from '../BasicButton'
//Nyambura --Imported Food Item list 
import FoodItems from './FoodItems';
//Nyambura --Imported comments component 
import Comments from './Comments';
//Nyambura --Imported Logo component 
import Logo from '../Logo';
//Imported Pagination 
import Pagination from '../Pagination';
//Imported PopUp 
import Popup from './Popup';
import { createContext, useEffect, useState } from 'react';
import SubmitButton from './SubmitButton';
import { Link } from 'react-router-dom';

/*
Murphree - Context allows for information to be collected and passed through a select set of components
    - response context starts here & resultsPage in GetFoodList to give foodItem info
*/
export const SurveyContext = createContext();
export const SurveyProvider = ({children}) => {
    const [response, setResponse] = useState({});
    return( 
        <SurveyContext.Provider value={{response, setResponse}}>
            {children}
        </SurveyContext.Provider>
    );
}

function SurveyPage() {
    const [foodItemList, setFoodItemsList] = useState();
    const [comment, setComment] = useState();
    const [indivSurveyResults ,setIndivSurveyResults] = useState();
    
    /*working call to server and sqlite info -Sarah
    always add a , [] as second param in useeffect so it's only called once
    */

   //Murphree - calls for foodItems, sets info into response, alert popup of error
    useEffect(()=>{
        GetFoodList();
    }, []);

    async function GetFoodList(){
        const url = 'https://localhost:7183/api/FoodItems';
        try {
            const response = await fetch(url);
            if(!response.ok){
                throw new Error(`Response Status: ${response.status}`);
            }
            const json = await response.json();
            setFoodItemsList(json);
        } catch (error){
            console.log("surveypage error message", error.message)
            alert(error.message);
        }
    }

    return (
    
        <SurveyProvider>
            <div className="Container-fluid "> 
                {/* Header  */}
                <div>
                    <Logo/>
                </div>

                {/* Results Button for Survey Page, styled to start from opposite side */}
                <Link to='/results'>
                    <div className="d-flex flex-row-reverse">
                        <BasicButton text="Results"/>
                    </div>
                </Link>
                {/* StockMyFoodBank Header  */}
                <h1>
                    StockMyFoodBank
                </h1>

                {/* Container that hold view 1 survey page food items */}
                <div className="Container-md Stock-Color">
                    <FoodItems 
                    foodItemList = {foodItemList}
                    // {/* // _submitHandler={submitHandler} */}
                    />
                </div>
                {/* Pagination - SM removing for now for prototype
                <div>
                    <Pagination />

                </div> */}

                {/* Comments section added for view 1 survey page  */}
                <div>
                    <Comments />
                </div>

                {/* Submit Button for Survey Page, styled to be in the middle of page */}
                <div className="d-flex justify-content-center ">
                    <SubmitButton />
                </div>
                {/* Popup modal can alter header and text using props to show error and submitted popup when submit button is clicked  */}
                <div>
                    <Popup/>
                </div>

                {/* Footer for view 1 survey page */}
                <footer>
                    <Logo />
                </footer>
            </div>
        </SurveyProvider>
  );
}

export default SurveyPage;