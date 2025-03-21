import SPRow from "./SPRow";

function SPColumn ({header, columnType, foodItemList, numbered }){
    const List = numbered ? OrderedList : UnorderedList;
    return (
        <div className="card card-body flex-fill">
            <div className="card-header row-1">
                <h5>{header}</h5>
            </div>
            <List className={`list-group ${numbered ? 'list-group-numbered' : ''}`}>
                {Array.isArray(foodItemList) ? foodItemList.map((foodItem) => {
                    return( 
                        <SPRow
                            foodItem = {foodItem}
                            rowType = {columnType}           
                        />
                    );
                }) : <p>No items available</p>}
            </List>
        </div>
    );
}
export default SPColumn;

const OrderedList = ({ children, ...props }) => {
    return <ol {...props}>{children}</ol>;
}

const UnorderedList = ({ children, ...props }) => {
    return <ul {...props}>{children}</ul>;
}
