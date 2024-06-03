import { ReviewType } from '../../../../ReviewType';
import defaultAva from "./../../../../assets/avatar-svgrepo-com.svg"
import "./Review.css"

type ReviewProps = {
  review: ReviewType;
};

const Review = ({ review }: ReviewProps): JSX.Element => {

  return (
    <>
      <div className="reviewBlock">
        <img className="reviewBlock_ava" src={defaultAva} alt="ava" />
        <div className="reviewBlock_textInfo">
          <h3>{review.name}</h3>
          <p>{review.comment}</p>
        </div>
        <h2 className="reviewBlock_averageRate">{review.averageRate}/5</h2>
      </div>
    </>
  )
}

export default Review
