import SPRow from "./SPRow";

function SPColumn ({header, columnType, foodItemList}){
    // const [rowItem, setRowItem] = useState();

    const OnNewFoodItem = () => {
        
    };


    return (
        <div className="card card-body flex-fill .bg-secondary-subtle">
            <div className="card-header row-1">
                <h5>{header}</h5>

            </div>
            {/* <div className="row-5 list-group list-group-numbered">
                {foodItemList.map((foodItem)=>{
                    return( 
                        <div>
                            <SPRow
                            // foodSelectionRowInput = {rowItem}           
                            />
                        </div>
                    );
                })}
            </div> */}
        </div>
    );
}
export default SPColumn;