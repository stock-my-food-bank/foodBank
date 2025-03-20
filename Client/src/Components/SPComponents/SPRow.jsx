function SPRow (props){
    const [count, foodSelectionRowInput, submitHandler] = props

    return (
        <div className="row .bg-warning-subtle" >
            {/* <div className="col-2">{count}</div> */}
            <div className="col-6 d-flex"> 
                {foodSelectionRowInput}
            </div>
            <div className="ms-2 me-auto">
                <div className="fw-bold"> 
                    FoodItemDesc
                </div>
                <p>
                    Description
                </p>
            </div>
        </div>
    )
}

export default SPRow;

