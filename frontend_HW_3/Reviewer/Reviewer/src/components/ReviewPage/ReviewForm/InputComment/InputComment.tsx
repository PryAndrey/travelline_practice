import { useEffect, useRef } from "react";
import "./InputComment.css";

interface InputNameProps {
  value: string;
  setValue: (name: string, value: string) => void;
}

const InputComment = ({ value, setValue }: InputNameProps): JSX.Element => {
  const commentRef = useRef<HTMLTextAreaElement>(null);
  
  useEffect(() => {
    if (commentRef.current) {
      commentRef.current.style.height = 'auto';
      commentRef.current.style.height = `${commentRef.current.scrollHeight}px`;
    }
  }, [value]);

  const handleChange = () => {
    if (commentRef.current) {
      setValue(commentRef.current.name, commentRef.current.value)
    }
  }

  return (
    <>
      <div className="inputCommentBlock">
        <textarea
          ref={commentRef}
          className="inputComment_input"
          name="comment"
          value={value}
          onChange={handleChange}
          required
          placeholder="Напишите, что понравилось, что было непонятно"
        />
      </div>
    </>
  )
}

export default InputComment
