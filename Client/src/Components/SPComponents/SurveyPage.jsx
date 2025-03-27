//Nyambura --Imported Basic Button Styling  
import { BasicButton } from '../BasicButton';
//Nyambura --Imported Food Item list 
import { FoodItems } from './FoodItems';
//Nyambura --Imported comments component 
import { Comments } from './Comments';
//Nyambura --Imported Logo component 
import { Logo } from '../Logo';
import { createContext, useEffect, useState } from 'react';
import { SubmitButton } from './SubmitButton';
import { Link } from 'react-router-dom';
import { fetchApi } from '../../helpers/fetch';

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

export const SurveyPage = () => {
    const [foodItemList, setFoodItemsList] = useState();
    
    /*working call to server and sqlite info -Sarah
    always add a , [] as second param in useeffect so it's only called once
    */

   //Murphree - calls for foodItems, sets info into response, alert popup of error
    useEffect(()=>{
        GetFoodList();
    }, []);

    async function GetFoodList(){
        const url = 'https://stockmyfoodbankapi-159895373187.us-central1.run.app/api/FoodItems';
        try {
            const response = await fetchApi(url);
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
                {/* Accessibility --Aria-label */}
                <Link to='/results'>
                    <div className="d-flex flex-row-reverse">
                        <BasicButton text="Results" aria-label="Go to Results Page"/>
                    </div>
                </Link>
                {/* StockMyFoodBank Header  */}
                <h1 id="SurveyPageHeader" tabIndex="0">
                    StockMyFoodBank
                </h1>

                {/* Container that hold view 1 survey page food items */}
                <div className="Container-md Stock-Color tablet-font" id="foodItemSelection">
                    <FoodItems 
                    foodItemList = {foodItemList}
                    />
                </div>
                {/* Comments section added for view 1 survey page  */}
                <div aria-labelledby="Insert Comments Section tablet-font" tabIndex="0">
                    <Comments />
                </div>

                {/* Submit Button for Survey Page, styled to be in the middle of page */}
                  {/* Accessibility --Aria-label */}
                <div className="d-flex justify-content-center " tabIndex="0">
                    <SubmitButton aria-label="Submit yur survey answers" />
                </div>
                {/* Footer for view 1 survey page */}
                <footer>
                    <Logo />
                </footer>
            </div>
        </SurveyProvider>
  );
}
