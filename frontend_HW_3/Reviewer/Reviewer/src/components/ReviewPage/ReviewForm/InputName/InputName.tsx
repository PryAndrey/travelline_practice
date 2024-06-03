import { useRef } from "react";
import "./InputName.css";

interface InputNameProps {
  value:
  string;
  setValue: (name: string, value: string) => void;
}

const InputName = ({ value, setValue }: InputNameProps): JSX.Element => {

  const nameRef = useRef<HTMLDivElement>(null);

  const handleFocus = () => {
    nameRef.current?.classList.add("inputName_name-selected");
  }
  const handleBlur = () => {
    nameRef.current?.classList.remove("inputName_name-selected");
  }

  return (
    <>
      <div className="inputNameBlock">
        <div className="inputName_name" ref={nameRef}>*Имя</div>
        <input className="inputName_input"
          name="name"
          type="text"
          value={value}
          onChange={event => setValue(event.target.name, event.target.value)}
          onFocus={handleFocus}
          onBlur={handleBlur}
          required
          placeholder="Как вас зовут?"
        />
      </div>
    </>
  )
}

export default InputName
