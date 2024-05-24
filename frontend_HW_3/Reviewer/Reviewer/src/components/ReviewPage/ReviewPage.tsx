import { useState } from 'react'
import './App.css'
import ReviewList from './ReviewList/ReviewList';
import ReviewForm from './ReviewForm/ReviewForm';


const ReviewPage = (): JSX.Element => {
  const [reviews, setReviews] = useState([]);

  // const handleAddReview = () => {
  //   setReviews((revs) => [...revs, newReview]);
  // };

  return (
    <>
      <div>
        <h2>Помогите нам сделать процесс бронирования лучше</h2>
        <ReviewForm />
      </div >
      <div>
        <ReviewList reviews={reviews} />
      </div>
    </>
  )
}

export default ReviewPage
