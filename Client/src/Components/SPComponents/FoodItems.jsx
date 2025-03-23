//Murphree - upper containter and using SPColumn component for repeatable formatting -- columnType determines what component to use in SPRow
import { SPColumn } from "./SPColumn";

export const FoodItems = ({foodItemList}) => {

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
