import { ReviewType } from '../../../ReviewType';
import Review from './Review/Review';
import './ReviewList.css'

type ReviewListProps = {
  reviews: ReviewType[];
};

const ReviewList = ({ reviews }: ReviewListProps): JSX.Element => {

  return (
    <>
      <div className="reviewList">
        {reviews.map((r, i) => (
          <Review review={r} key={i} />
        ))}
      </div>
    </>
  )
}

export default ReviewList
