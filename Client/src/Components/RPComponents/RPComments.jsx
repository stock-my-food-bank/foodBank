import { useEffect, useState } from "react";

//Nyambura --Functional component for results page comments for foodbank manager to review
export const RPComments = () => {
    const [comments, setComments] = useState();
    const [commentCount, setCommentCount] = useState(5);
    
    useEffect(() => {
        const fn = async () => {
            const url = 'https://localhost:5252/api/Comments';
            try {
                const response = await fetch(url);
                if(!response.ok){
                    throw `Response Status: ${response.status}`;
                }
                const json = await response.json();
                setComments(json);
            } catch (error){
                console.log("Results Comments Component Error", error.message)
                alert(error.message);
            }
        };
        fn();
    }, []);

    //Murphree - loading to show while comments load so page has a moment to collect comments and avoid error
    if (!comments) {
        return 'loading...';
    }

    //Murphree - if showMore is clicked all comments will show, starts with 5 comments visable
    const showMoreOnClick = () => {
        setCommentCount(commentCount + 5);
    }

    //Murphree - starts at beginning of array of comments, if commentCount is less than or equal to comments.length, slices at commentCount, otherwise slices at comments.length
    const visibleComments = comments.slice(0, commentCount <= comments.length ? commentCount : comments.length);

    //Murphree - using id fragment to connect showMore link to visiable comments 
    return (
        <>
           <ul id='comment-table' className="list-group m-2 pb-3">
                {visibleComments.map(c => <Comment comment={c.comment} date={c.dateTime} />)}
            </ul>
            <div>
                {commentCount < comments.length && <a href="#comment-table" onClick={showMoreOnClick}>Show More</a>}
            </div>
        </>
    );
}

//Murphree - indiviudal comment component
export const Comment = ({ comment, date }) => {
    return (
        <li className="list-group-item d-flex justify-content-between align-items-center">
            {comment}
            <span className="badge text-bg-light rounded-pill">Date: {date}</span>
        </li>
    )
}
