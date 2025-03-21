import SPColumn from "./SPColumn";

function FoodItems ({foodItemList}) {

    return (
        <>
            <div class="container-fluid ">
                <div className="row align-items-start p-4 pb-4">
                    <div className="col p-0">
                        <SPColumn
                            header = "Items being considered by the foodbank:"
                            columnType ="foodItems"
                            foodItemList={foodItemList}
                            numbered
                        />
                    </div>
                    <div className="col p-0">
                        <SPColumn
                            header = "Would you select this item during a visit?"
                            columnType = "buttons"
                            foodItemList={foodItemList}
                        />
                    </div>
                </div>
            </div> 
        </>
    );
    
}

export default FoodItems;