function SurveyButton ({foodItemId}) {
    return (
        <div className="d-flex flex-fill flex-column h-100 justify-content-center">
            <div className="btn-group" role="group" aria-label="Basic outlined example">
                <button type="button" className="btn btn-lg btn-outline-dark">Yes</button>
                <button type="button" className="btn btn-outline-dark">No</button>
                <button type="button" className="btn btn-outline-dark">Skip</button>
            </div>
        </div>
    );
}

export default SurveyButton;