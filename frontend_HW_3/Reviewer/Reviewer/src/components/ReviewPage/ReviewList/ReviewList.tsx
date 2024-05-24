import './App.css'
import Review, { ReviewType } from './Review/Review';

type ReviewListProps = {
  reviews: ReviewType[];
};

const ReviewList = ({ reviews }: ReviewListProps): JSX.Element => {

  return (
    <>
      {reviews.map((r, i) => (
        <Review review={r} key={i}/>
      ))}
    </>
  )
}

export default ReviewList
