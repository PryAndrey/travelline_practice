import { useEffect, useRef } from "react";
import "./RateBar.css"
import { FieldType } from "../../../../ReviewType";

type RateValueParams = {
  emojiClass: string
}

const rateParams: RateValueParams[] = [
  { emojiClass: "angryFace" },
  { emojiClass: "slightlyFrowningFace" },
  { emojiClass: "neutralFace" },
  { emojiClass: "slightlySmilingFace" },
  { emojiClass: "grinningFace" }
];

interface RateBarProps {
  field: FieldType;
  setValue: (name: string, value: number) => void;
}

const RateBar = ({ field, setValue }: RateBarProps): JSX.Element => {
  const inputRef = useRef<HTMLInputElement>(null);
  const datalistRef = useRef<HTMLDataListElement>(null);

  useEffect(() => {
    if (field.value === 0) {
      datalistRef.current?.classList.remove(...datalistRef.current?.classList);
      datalistRef.current?.classList.add("initPoints");
      inputRef.current?.classList.remove(...inputRef.current?.classList);
      inputRef.current?.classList.add("rateBar");
    }
  }, [field]);

  const handleRangeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setValue(event.target.name, Number(event.target.value));

    datalistRef.current?.classList.remove(...datalistRef.current?.classList);
    datalistRef.current?.classList.add("emptyPoints", rateParams[Number(event.target.value) - 1].emojiClass);
    inputRef.current?.classList.remove(...inputRef.current?.classList);
    inputRef.current?.classList.add("rateBar", rateParams[Number(event.target.value) - 1].emojiClass);
  };

  const handleClick = () => {
    if (field.value === 0) {
      if (inputRef.current)
        setValue(inputRef.current.name, 1);
      datalistRef.current?.classList.remove(...datalistRef.current?.classList);
      datalistRef.current?.classList.add("emptyPoints", rateParams[0].emojiClass);
      inputRef.current?.classList.remove(...inputRef.current?.classList);
      inputRef.current?.classList.add("rateBar", rateParams[0].emojiClass);
    }
  }

  return (
    <>
      <div className="inputRangeBlock">
        <div className="inputRange">
          <datalist
            id="tickmarks"
            className="initPoints"
            ref={datalistRef}>
            <option value="1" />
            <option value="2" />
            <option value="3" />
            <option value="4" />
            <option value="5" />
          </datalist>
          <input
            ref={inputRef}
            name={field.name}
            type="range"
            min="1"
            max="5"
            step="1"
            value={field.value}
            onChange={handleRangeChange}
            onMouseDown={handleClick}
            className="rateBar"
            required
            list="tickmarks"
          />
        </div>
        <h3>{field.title}</h3>
      </div>
    </>
  );
};

export default RateBar
