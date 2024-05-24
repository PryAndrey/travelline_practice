import './App.css'

export type ReviewType = {
  averageRate: number,
  name: string,
  comment: string,
};

type ReviewProps = {
  review: ReviewType;
  key: number;
};

const Review = ({ review, key }: ReviewProps): JSX.Element => {

  return (
    <>
      {key}
    ava
      {review.averageRate}
      {review.name}
      {review.comment}
    </>
  )
}

export default Review
