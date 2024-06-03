import { useEffect, useState } from 'react'
import './ReviewPage.css'
import ReviewList from './ReviewList/ReviewList';
import ReviewForm from './ReviewForm/ReviewForm';
import { ReviewType } from '../../ReviewType';

const ReviewPage = (): JSX.Element => {
  const [reviews, setReviews] = useState<ReviewType[]>([]);

  useEffect(() => {
    const storedData = localStorage.getItem('review-data');
    if (storedData) {
      const data = JSON.parse(storedData);
      setReviews([...data.reviews]);
    }
  }, []);

  useEffect(() => {
    localStorage.setItem('review-data', JSON.stringify({ reviews }));
  }, [reviews]);

  const handleNewReview = (value: ReviewType) => {
    setReviews([
      ...reviews, value
    ]);
  };

  return (
    <>
      <div className='reviewPageBlock_form'>
        <h2>Помогите нам сделать процесс бронирования лучше</h2>
        <ReviewForm setReviews={handleNewReview} />
      </div >
      <ReviewList reviews={reviews} />
    </>
  )
}

export default ReviewPage
