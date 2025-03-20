import SPColumn from "./SPColumn";

function FoodItems (props) {
    const [submitHandler] = props
         //call to get foodItem List


    return (
        <>
            <div class="container-fluid ">
    
                <div className="row align-items-start p-5 pb-0">
                    <SPColumn
                        header = "Items being considered by the foodbank:"
                        foodItemList = {_foodItemList}
                        columnType ="foodItems"
                    />
                    {/* <SPColumn
                        header = "Would you select this item during a visit?"
                        foodItemList = {_foodItemList}
                        columnType = "buttons"
                    /> */}
                </div>
            </div> 
        </>
    );
    
}

export default FoodItems;