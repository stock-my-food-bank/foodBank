import { FoodItemDesc } from "./foodItemDesc";
import { SurveyButton } from "./surveyButton";

//Murphree - column type set by prop, information passed through as needed
export const SPRow = ({foodItem, rowType}) => {
    if (rowType === "foodItems"){
        return (
            <li className="list-group-item d-flex align-items-start list-item">
                <FoodItemDesc 
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

