
//Murphree - handles consistant formatting of foodItem images, title is for alt tag for screen readers
export const FoodImg = ({img, foodItemTitle}) => {
    
    return (
        <img 
            src={img}
            alt={`${foodItemTitle} Image`}
            className="align-middle p-0 foodImg tablet-img"
        />
    )
}
