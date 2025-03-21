import { useState } from "react";
import FoodItemDesc from "./foodItemDesc";
import SurveyButton from "./surveyButton";

function SPRow ({foodItem, rowType}){
    if (rowType === "foodItems"){
        return (
            <li className="list-group-item d-flex align-items-start list-item">
                <FoodItemDesc 
                    foodItemId = {foodItem.id}
                    foodItemTitle = {foodItem.title}
                    foodItemImg = {foodItem.image}                
                />
            </li>
        );
    }
    if (rowType === "buttons"){
        return(
            <li className="list-group-item list-group-item-action list-item">
                <SurveyButton 
                    foodItemId={foodItem.id}
                />
            </li>
        );
    }
}
export default SPRow;

