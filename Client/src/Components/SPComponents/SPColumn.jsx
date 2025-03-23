import { SPRow } from "./SPRow";


//Murphree - List() sets if numbers needed, maps through the foodItem list to create as many rows as foodItems pulled from API, no items comment given if empty array
export const SPColumn = ({header, columnType, foodItemList, numbered }) => {
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

//Murphree - used for left column to add numbers
export const OrderedList = ({ children, ...props }) => {
    return <ol {...props}>{children}</ol>;
}

//Murphree - used for right column to not double on numbering
export const UnorderedList = ({ children, ...props }) => {
    return <ul {...props}>{children}</ul>;
}
