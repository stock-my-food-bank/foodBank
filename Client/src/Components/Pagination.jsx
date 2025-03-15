//Nyambura-Pagination
function Pagination () {
    return (

        <>
            <nav aria-label="Page navigation example ">
                <ul className="pagination justify-content-center m-3 "> {/*center, margin of 3 */}

                    <li className="page-item"> {/*Icon for left */}
                        <a className="page-link text-dark" href="#" aria-label="Previous">
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>
                    {/*More list items can be added here for more pages */}
                    <li className="page-item"><a class="page-link text-dark" href="#">1</a></li> {/*color of text */}
                   
                    <li class="page-item">
                        <a class="page-link text-dark" href="#" aria-label="Next"> {/*Icon for right*/}
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </nav>
        </>
    );

}
export default Pagination; 