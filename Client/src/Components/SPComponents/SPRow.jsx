function SPRow (props){
    const [count, foodSelectionRowInput, submitHandler] = props

    return (
        <div className="row">
            {/* <div className="col-2">{count}</div> */}
            <div className="col-6"> 
                {foodSelectionRowInput}
            </div>
        </div>
    )
}

export default SPRow;

