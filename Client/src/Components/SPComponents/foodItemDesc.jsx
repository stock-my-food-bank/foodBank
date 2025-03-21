import FoodImg from "./FoodImg";


//Murphree - Repeatable component to display the left side of the surveyPage, listing foodItems
function FoodItemDesc ({foodItemId, foodItemTitle, foodItemImg}) {
    
    return(
        <div className="d-flex justify-content-around flex-column flex-fill">
            <div>{foodItemTitle}</div>
            <div> 
                <FoodImg
                    img={foodItemImg}
                    foodItemTitle={foodItemTitle}
                />
            </div>
        </div>
    );
}
export default FoodItemDesc;