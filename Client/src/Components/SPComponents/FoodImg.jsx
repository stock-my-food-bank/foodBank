function FoodImg ({img, foodItemTitle}) {

    return (
        <img 
            src={img}
            alt={`${foodItemTitle} Image`}
            className="align-middle p-0 foodImg"
            style={{ maxHeight: '5.5rem' }}
        />
    )
}
export default FoodImg;