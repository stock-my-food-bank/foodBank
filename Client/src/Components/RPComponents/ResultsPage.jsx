//Nyambura --Results page
import { Link } from "react-router-dom";
//logo imported 
import { Logo } from "../Logo";
//basic button stylin imported 
import { BasicButton } from "../BasicButton";
//RPComments imported 
import { RPComments } from "./RPComments";
import { useEffect, useState } from "react";


/*
Murphree - Context allows for information to be collected and passed through a select set of components
    - response context starts here & resultsPage in GetFoodList to give foodItem info
*/
export const ResultsPage = () => {
    const [votes, setVotes] = useState();
    const [foodItems, setFoodItems] = useState({});

    //SM- fn stands for function
    useEffect(() => {
        const fn = async () => {
            const url = 'https://stockmyfoodbankapi-159895373187.us-central1.run.app/api/SurveyFoodItemResults/api/SurveyFoodItemResults';
            try {
                const response = await fetch(url);
                if(!response.ok){
                    throw `Response Status: ${response.status}`;
                }
                const json = await response.json();
                setVotes(json);
            } catch (error){
                console.log("resultsPage results error", error.message)
                alert(error.message);
            }
        };
        fn();
    }, []);

    /*
    Murphree - Calls to get foodItems listing to get name to match with Id and put into fooditemMap
            - ToDO: potential future change--figure out how to keep foodItems list from surveyPage to limit 3rd party API call
    */
    useEffect(() => {
        const fn = async () => {
            const url = 'https://stockmyfoodbankapi-159895373187.us-central1.run.app/api/SurveyFoodItemResults/api/FoodItems';
            try {
                const response = await fetch(url);
                if(!response.ok){
                    throw `Response Status: ${response.status}`;
                }
                const json = await response.json();
                const foodItemMap = {};
                json.forEach(fi => foodItemMap[fi.id] = fi.title);
                setFoodItems(foodItemMap);
            } catch (error){
                console.log("resultsPage foodItem error", error.message)
            }
        };
        fn();
    }, []);

    //Murphree - DO NOT REMOVE - need loading for while waiting for calls or page breaks trying to render what's not there yet
    if (Object.keys(foodItems).length === 0) {
        return "loading..."
    }

    return (
        <div> 
            {/* Header  */}
            <div>
                <Logo/>
            </div>
            {/* Back Button for Results Page */}
            <Link to="/" >
                <div className="d-flex mt-2 ms-5" role="navigation">
                    <BasicButton text="Back" aria-label="Go Back to Previous Page"/>
                </div>
            </Link>
            {/* StockMyFoodBank Header  */}
            <h1 style={{ marginTop: '-3.5rem', marginLeft: '2rem' }} id="main-title">
                StockMyFoodBank
            </h1>
            <div className="container Stock-Color">
                <h2 className="pt-2" >
                    Results
                </h2>
                <div className="row row-cols-2 m-1 justify-content-around">
                    {/*Table that will display individual item results in table format */}
                    {/*Murphree - maps through votes pulled from API call and adds in foodItems from other call*/}
                    {votes?.map(({ foodItemId, voteCountYes, voteCountNo }) => (
                        <ItemResults
                            itemName={foodItemId}
                            yesCount={voteCountYes}
                            noCount={voteCountNo}
                            foodItemMap={foodItems}
                        />
                    ))}
                </div>
                <div className="tablet-font">
                    <RPComments />
                </div>
            </div> 
            {/* Footer for view 2 Results page */}
            <footer>
                <Logo />
            </footer>

        </div>        
    );
}

/*Murphree - component to handle inputting listing of results through map in table format
             uses gutter bootstrap to separate tables
             foodItemMap takes in foodItems to so can match title to Id to name results
*/
export const ItemResults = ({ itemName, yesCount, noCount, foodItemMap }) => {
    return (
        <div className="col-5 gy-3 bg-light tablet-font">
            <div className="pb-1" tabIndex="0">{foodItemMap[itemName]}</div>
            <table className="table table-bordered" aria-describedby="results-heading" tabIndex="0">
                <tbody >
                    <tr>
                        <th  scope="row" tabIndex="0">Yes Votes</th>
                        <td  tabIndex="0">{yesCount}</td>
                    </tr>
                    <tr>
                        <th scope="row" tabIndex="0">No Votes</th>
                        <td  tabIndex="0">{noCount}</td>
                    </tr>
                </tbody>
            </table>
        </div> 
    )
}


