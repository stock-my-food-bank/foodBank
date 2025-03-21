//Nyambura --Results page
import { Outlet } from "react-router-dom";

//logo imported 
import Logo from "../Logo";
//basic button stylin imported 
import BasicButton from "../BasicButton";
//RPComments imported 
import RPComments from "./RPComments";
import { useEffect, useState } from "react";


/*
Murphree - Context allows for information to be collected and passed through a select set of components
    - response context starts here & resultsPage in GetFoodList to give foodItem info
*/
function ResultsPage() {
    const [votes, setVotes] = useState();
    const [foodItems, setFoodItems] = useState({});

    useEffect(() => {
        const fn = async () => {
            const url = 'https://localhost:7183/api/SurveyFoodItemResults';
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
            const url = 'https://localhost:7183/api/FoodItems';
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
                alert(error.message);
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
            <div className="d-flex mt-2 ms-5">
                <BasicButton text="Back"/>
            </div>
            {/* StockMyFoodBank Header  */}
            <h1 style={{ marginTop: '-3.5rem' }}>
                StockMyFoodBank
            </h1>
            <div className="container bg-info">
                <h2>
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
                <div>
                    <RPComments />
                </div>
            </div> 
            {/* Footer for view 2 Results page */}
            <div>
                <Logo />
            </div>

        </div>        
    );
}

/*Murphree - component to handle inputting listing of results through map in table format
             uses gutter bootstrap to separate tables
             foodItemMap takes in foodItems to so can match title to Id to name results
*/
const ItemResults = ({ itemName, yesCount, noCount, foodItemMap }) => {
    return (
        <div className="col-5 gy-3 bg-light">
            <div>{foodItemMap[itemName]}</div>
            <table class="table table-bordered">
                <tbody>
                    <tr>
                        <th>Yes Votes</th>
                        <td>{yesCount}</td>
                    </tr>
                    <tr>
                        <th>No Votes</th>
                        <td>{noCount}</td>
                    </tr>
                </tbody>
            </table>
        </div> 
    )
}


export default ResultsPage;

