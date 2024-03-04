import { Slot, component$ } from "@builder.io/qwik";

export default component$(() => {
    return (
      <div class="grid grid-cols-2 gap-2">
        <Slot />
      </div>
    )
  });