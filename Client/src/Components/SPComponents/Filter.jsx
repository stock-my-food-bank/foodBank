function Filter () {
    return (
        <div class="dropdown d-flex flex-row-reverse mt-2">
            <button className="btn btn-outline-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Filter
            </button>
            <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <a className="dropdown-item" href="#">Non-Allergen</a> 
                <a className="dropdown-item" href="#">Allergen</a>
                
            </div>
        </div>

    );
}

export default Filter;