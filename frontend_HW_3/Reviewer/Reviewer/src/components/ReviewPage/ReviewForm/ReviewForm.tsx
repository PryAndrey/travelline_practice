import './App.css'
import InputComment from './InputComment/InputComment'
import InputName from './InputName/InputName'
import RateBar from './RateBar/RateBar'

const ReviewForm = (): JSX.Element => {

  return (
    <>
      <form>
        <div>
          <RateBar></RateBar>
          <RateBar></RateBar>
          <RateBar></RateBar>
          <RateBar></RateBar>
          <RateBar></RateBar>
        </div>
        <InputName/>
        <InputComment/>
        <button type="button" onClick={handleAddReview}></button>
      </form>
    </>
  )
}

export default ReviewForm
