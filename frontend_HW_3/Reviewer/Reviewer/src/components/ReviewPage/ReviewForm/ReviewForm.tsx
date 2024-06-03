import { useEffect, useRef, useState } from 'react'
import InputComment from './InputComment/InputComment'
import InputName from './InputName/InputName'
import RateBar from './RateBar/RateBar'
import { FieldType, ReviewType } from '../../../ReviewType'
import './ReviewForm.css'

interface ReviewFormProps {
  setReviews: (value: ReviewType) => void;
}

interface ReviewInputType {
  fields: FieldType[],
  name: string,
  comment: string,
};

const ReviewForm = ({ setReviews }: ReviewFormProps): JSX.Element => {
  const [formData, setFormData] = useState<ReviewInputType>({
    fields: [
      { name: "speed", title: "Скорость", value: 0 },
      { name: "service", title: "Сервис", value: 0 },
      { name: "clear", title: "Чистенько", value: 0 },
      { name: "place", title: "Место", value: 0 },
      { name: "culture", title: "Культура речи", value: 0 }
    ],
    name: "",
    comment: "",
  });

  const submitButtonRef = useRef<HTMLButtonElement>(null);

  useEffect(() => {
    if (
      !formData.fields.some(field => field.value === 0) &&
      formData.name !== "" && formData.comment !== ""
    ) {
      submitButtonRef.current?.classList.remove(...submitButtonRef.current?.classList);
      submitButtonRef.current?.classList.add("formButton", "formButton_ready");
    } else {
      submitButtonRef.current?.classList.remove(...submitButtonRef.current?.classList);
      submitButtonRef.current?.classList.add("formButton");
    }
  }, [formData]);

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (formData.fields.some(field => field.value === 0)) {
      return;
    }
    const numericFields = formData.fields.map(field => Number(field.value));
    const sum = numericFields.reduce((acc, value) => acc + value, 0);
    const averageRate = sum / numericFields.length;

    setReviews({
      name: formData.name,
      comment: formData.comment,
      averageRate: averageRate
    });
    setFormData({
      fields: formData.fields.map(field => ({ ...field, value: 0 })
      ),
      name: "",
      comment: "",
    });
  }

  const handleInputChange = (name: string, value: string) => {
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleFieldInputChange = (name: string, value: number) => {
    const fieldIndex = formData.fields.findIndex(el => el.name === name);

    if (fieldIndex !== -1) {
      setFormData({
        ...formData,
        fields: formData.fields.map((field, index) =>
          index === fieldIndex
            ? { ...field, value: value }
            : field
        ),
      })
    }
  }

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div className="rateBarsBlock">{
          Object.values(formData.fields).map((el, ind) =>
            <RateBar key={ind} field={el} setValue={handleFieldInputChange}></RateBar>
          )}
        </div>
        <InputName value={formData.name} setValue={handleInputChange} />
        <InputComment value={formData.comment} setValue={handleInputChange} />
        <button ref={submitButtonRef} className="formButton" type="submit">Отправить</button>
      </form>
    </>
  )
}

export default ReviewForm
