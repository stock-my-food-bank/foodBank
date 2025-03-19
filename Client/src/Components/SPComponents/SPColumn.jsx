import SPRow from "./SPRow";

function SPColumn (props){
    const [header, foodItemList, columnType]=props
    const [rowItem, setRowItem] = useState();

    const OnNewFoodItem = () => {
        
    };

    return (
        <div className="card card-body flex-fill">
            <div className="card-header row-1">
                <span>{header}</span>
            </div>
            <div className="row-5 list-group list-group-numbered">
                {foodItemList.map((foodItem)=>{
                    return( 
                        <div>
                            <SPRow
                            foodSelectionRowInput = {rowItem}           
                            />
                        </div>
                    );
                })}

            </div>
        </div>
    );
}
export default SPColumn;