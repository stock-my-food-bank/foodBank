function foodItemDesc (props) {
    const [foodItem]=props;
    return(
        <div>
           <div className="ms-2 me-auto">
                <div className="fw-bold"> 
                    {foodItem.title}
                </div>
                <img
                src={image}
                alt={foodItem.title}
                />
            </div> 
        </div>
    );
}
export default foodItemDesc;

// {/* Nyambura Column 1 --Food items, Card Bootstrap */}
// <div className="card col-6 d-flex ">
// <div className="card-header">
//         Items being considered by the foodbank:
// </div>

// <div className="card-body flex-fill">
//     {/* Nyambura -- Ordered list that holds every food item that will be considered, List Group Bootstrap  */}
//     <ol className="list-group list-group-numbered">

//         {/* Individual Food List Item example  */}
//         <li className="list-group-item d-flex justify-content-between align-items-start">
//             <div className="ms-2 me-auto">
//                 <div className="fw-bold"> 
//                     Item 1
//                 </div>
//                 <p>
//                     Description
//                 </p>
//             </div>
//         </li>
            
//     </ol>
// </div>
// </div>