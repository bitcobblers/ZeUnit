import { component$ } from "@builder.io/qwik";

export default component$((props : { code : string, language : string, theme: any}) => {
  return (
    <pre>
      {props.code}
    </pre>
  );
});